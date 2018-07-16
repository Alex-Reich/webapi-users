<template>
    <div class="container">
        <div v-for="keep in keeps" :key="keep.id" class="card text-center">
            <h3 class="card-title">{{keep.id}}. {{keep.name}}</h3>
            <div class="container">
                <img :src="keep.img" alt="">
                <div class="buttons">
                    <button class="btn" data-toggle="modal" data-target="#viewingKeepModal" @click="addView(keep)">View</button>
                    <div v-if="user.id = keep.userId">
                        <button class="btn btn-danger" @click="deleteKeep(keep)">Delete</button>
                    </div>
                </div>
            </div>
            <h3 class="card-text">Description: {{keep.description}}</h3>
            <h3 class="card-text">Views: {{keep.views}} Saves: {{keep.saves}}</h3>


            <!-- View Keep Modal -->
            <div class="modal fade" id="viewingKeepModal" tabindex="-1" role="dialog" aria-labelledby="viewingKeepModalTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Keep: {{keep.name}}</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <form v-on:submit.prevent="updateKeep">
                            <div class="modal-body">
                                <div class="container">
                                    <img :src="keep.img" alt="">
                                    <h3 class="card-text">Description: {{keep.description}}</h3>
                                    <h3 class="card-text">Views: {{keep.views}} Saves: {{keep.saves}}</h3>
                                </div>
                                <div class="form-group">
                                    <select v-model="vault">
                                        <option disabled value="">Select a Vault</option>
                                        <option v-for="vault in userVaults" :key="vault.id" value="vault">{{vault.name}}</option>
                                    </select>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                <button class="btn btn-primary btn-primary" @click="updateKeep" data-dismiss="modal">Save</button>
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
                    vaultId: ''
                },
                vault: {}
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
            // viewKeep needs to router.push to a component that contains info for a single keep.
            // Need to create this component and add it to routes
            // On this page the single keep will be displayed
            // Orrrrrrrr
            // Have the view button open up a modal with the single keep. Can add to vault from this modal. Button will ++ view count for that keep
            updateKeep(updatedKeep) {
                console.log(this.updatedKeep)
                console.log("Lets update")
            },
            addView(keep) {
                keep.views++
                this.$store.dispatch('updateKeep', keep)
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