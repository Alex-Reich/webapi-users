<template class>
    <div class="container ">
        <div>

            <div v-for="keep in keeps" v-if="keep.public == 1" :key="keep.id" class="card text-center outline">
                <h3 class="card-title">Keep Name: {{keep.name}}</h3>
                <div class="container">
                    <img :src="keep.img" alt="">
                    <div class="buttons">
                        <button class="btn" @click="addView(keep)">View</button>
                        <div v-if="user.id == keep.userId && keep.public == 0">
                            <button class="btn btn-danger" @click="deleteKeep(keep)">Delete</button>
                        </div>
                    </div>
                </div>
                <h3 class="card-text">Description: {{keep.description}}</h3>
                <h3 class="card-text">Views: {{keep.views}} Saves: {{keep.saves}}</h3>
            </div>


            <!-- View Keep Modal -->
            <div class="modal fade" id="viewingKeepModal" tabindex="-1" role="dialog" aria-labelledby="viewingKeepModalTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Keep: {{viewKeep.name}}</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <form>
                            <div class="modal-body">
                                <div class="container">
                                    <img :src="viewKeep.img" alt="">
                                    <h3 class="card-text">Description: {{viewKeep.description}}</h3>
                                    <h3 class="card-text">Views: {{viewKeep.views}} Saves: {{viewKeep.saves}}</h3>
                                </div>
                                <div class="form-group">
                                    <select v-model="vault">
                                        <option disabled value="">Select a Vault</option>
                                        <option v-for="vault in userVaults" :key="vault.id" :value="vault">{{vault.name}}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-primary" @click="createVaultKeep(vault)" data-dismiss="modal">Save</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
    export default {
        name: 'Keep',
        data() {
            return {
                keep: {
                    vaultId: '',
                    public: 0
                    // add public property, include in updateKeep to switch from public to private
                },
                vault: {},
                viewKeep: {}
            }
        },
        mounted() {
            this.$store.dispatch('getKeeps')
            // this.$store.dispatch('getUserVaults', this.user)
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            userVaults() {
                return this.$store.state.userVaults
            },
            activeVault() {
                return this.$store.state.activeVault
            },
            keeps() {
                return this.$store.state.keeps
            }
        },
        methods: {
            updateKeep(keep) {
                keep.saves++
                console.log(keep)
                this.$store.dispatch('updateKeep', keep)
            },
            addView(keep) {
                keep.views++
                this.$store.dispatch('updateKeep', keep)
                this.viewKeep = keep
                $('#viewingKeepModal').modal('show')
            },
            deleteVault(vault) {
                this.$store.dispatch("deleteVault", vault)
            },
            deleteKeep(keep) {
                this.$store.dispatch("deleteKeep", keep)
            },
            createVaultKeep(vault) {
                console.log(this.viewKeep)
                this.viewKeep.saves++
                var vaultKeep = {
                    vaultId: vault.id,
                    keepId: this.viewKeep.id
                }
                console.log(vaultKeep)

                this.$store.dispatch('createVaultKeep', vaultKeep)
                this.$store.dispatch('updateKeep', this.viewKeep)

            }
        }
    }

</script>

<style>
    .container {
        position: relative;
        width: 100%;
    }

    .container .buttons {
        position: absolute;
        top: 80%;
        left: 45%;
        cursor: pointer;
        margin: auto;
        display: none;
    }

    .container:hover .buttons {
        display: inline-block;
    }
    .outline {
        border: 2px solid grey;
        background-color: lightgrey;
    }
    .bg {
        background-color: darkgrey; 
    }
</style>