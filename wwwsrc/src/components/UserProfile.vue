<template>
    <div>
        <div class="ownerProf">
            <div class="profIcon d-flex">
                <button class="btn btn-dark mr-auto rnd" data-toggle="modal" data-target="#createKeepModal">Create Keep</button>
                <button class="btn btn-dark ml-auto rnd" @click=logout()>Logout</button>

                <!-- create keep modal -->
                <div class="modal fade" id="createKeepModal" tabindex="-1" role="dialog" aria-labelledby="createKeepModalTitle" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="createKeepModalTitle">Create Keep</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <form v-on:submit.prevent="createKeep(newKeep)">
                                    <div class="form-group">
                                        <input v-model="newKeep.name" value="newKeep.name" type="text" name="keepName" placeholder="Keep Name" required>
                                        <input v-model="newKeep.img" value="newKeep.img" type="url" name="keepImg" placeholder="Image Url">
                                        <input v-model="newKeep.description" value="newKeep.description" type="text" name="keepDescription" placeholder="Keep Description"
                                            required>
                                    </div>
                                    <div class="form-group">
                                        <select v-model="newKeep.vaultId">
                                            <option disabled value="">Select a Vault</option>
                                            <option v-for="vault in vaults" :key="vault.id" value="newKeep.vaultId">{{vault.name}}</option>
                                        </select>
                                    </div>
                                    <div class="modal-footer">
                                            <button type="button" @click="createKeep(newKeep)" class="btn btn2" data-dismiss="modal">Save</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <h2 class="">Hello {{user.username}}</h2>
        </div>
    </div>
</template>

<script>
    import router from '../router'
    export default {
        name: 'UserProfile',
        data() {
            return {
                newKeep: {
                    name: '',
                    img: '',
                    description: '',
                    vaultId: '',
                }
            }
        },
        mounted() {
            if (!this.$store.state.user._id) {
                router.push({ name: 'Home' })
            }
        },
        computed: {
            user() {
                return this.$store.state.user;
            },
            vaults(){
                return this.$store.state.vaults;
            }
        },
        methods: {
            logout() {
                this.$store.dispatch('logout')
                this.$store.state.loggedIn = false
            },
            createKeep(newKeep) {
                console.log(newKeep)
                this.$store.dispatch('createKeep', newKeep)
            }
        }
    }




</script>

<style>
</style>