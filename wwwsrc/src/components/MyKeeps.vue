<template>
    <div class="container">
        <div>

            <div v-for="keep in keeps" v-if="keep.userId == user.id" :key="keep.id" class="card text-center">
                <h3 class="card-title">{{keep.id}}. {{keep.name}}</h3>
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
            <div class="modal fade" id="viewingMyKeepModal" tabindex="-1" role="dialog" aria-labelledby="viewingKeepModalTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Keep: {{viewKeep.name}}</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <form v-on:submit.prevent="updateKeep(viewKeep)">
                            <div class="modal-body">
                                <div class="container">
                                    <img :src="viewKeep.img" alt="">
                                    <h3 class="card-text">Description: {{viewKeep.description}}</h3>
                                    <h3 class="card-text">Views: {{viewKeep.views}} Saves: {{viewKeep.saves}}</h3>
                                </div>
                                <div class="form-group">
                                    <select v-model="vault">
                                        <option disabled value="">Select a Vault</option>
                                        <option v-for="vault in userVaults" :key="vault.id" value="vault">{{vault.name}}</option>
                                    </select>

                                    <select v-model="updatedKeep.public">
                                        <option disabled value="">Public or private</option>
                                        <option value="1">Public</option>
                                        <option value="0">Private</option>
                                    </select>

                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                <button class="btn btn-primary btn-primary" @click="updateKeep(viewKeep)" data-dismiss="modal">Save</button>
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
                updatedKeep: {
                    vaultId: '',
                    public: 0
                },
                vault: {},
                viewKeep: {}
            }
        },
        mounted() {
            this.$store.dispatch('getKeeps')
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
            updateKeep(viewKeep) {
                console.log(viewKeep)
                this.viewKeep.shares++
                viewKeep.public = this.updatedKeep.public
                this.$store.dispatch('updateKeep', viewKeep)
                console.log("Keep updated", viewKeep)
            },
            addView(keep) {
                keep.views++
                this.$store.dispatch('updateKeep', keep)
                this.viewKeep = keep
                $('#viewingMyKeepModal').modal('show')
            },
            deleteVault(vault) {
                this.$store.dispatch("deleteVault", vault)
            },
            deleteKeep(keep) {
                this.$store.dispatch("deleteKeep", keep)
            }
        }
    }

</script>

<style>
</style>