<template>
    <div>
        <div class="ownerProf">
            <div class="profIcon d-flex">
                <button class="btn btn-dark mr-auto rnd" data-toggle="modal" data-target="#createKeepModal">Create Keep</button>
                <button class="btn btn-dark rnd m-auto" data-toggle="modal" data-target="#createVaultModal">Create Vault</button>
                <div v-if="toggleView">
                    <button class="btn btn-dark rnd m-auto" @click="viewToggle()">My Vaults</button>
                </div>
                <div v-if="!toggleView">
                        <button class="btn btn-dark rnd m-auto" @click="viewToggle()">My Keeps</button>
                </div>
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
                                            <option v-for="vault in userVaults" :key="vault.id" value="newKeep.vaultId">{{vault.name}}</option>
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

                <!-- create vault modal -->
                <div class="modal fade" id="createVaultModal" tabindex="-1" role="dialog" aria-labelledby="createVaultModalTitle" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="createVaultModalTitle">Create Vault</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <form v-on:submit.prevent="createVault(newVault)">
                                    <div class="form-group">
                                        <input v-model="newVault.name" value="newVault.name" type="text" name="vaultName" placeholder="Vault Name" required>
                                        <input v-model="newVault.description" value="newVault.description" type="text" name="vaultDescription" placeholder="Vault Description"
                                            required>
                                    </div>
                                    <!-- <div class="form-group">
                                            <select v-model="newVault">
                                                <option value="">

                                                </option>
                                            </select>
                                        </div> -->
                                    <div class="modal-footer">
                                        <button type="button" @click="createVault(newVault)" class="btn btn2" data-dismiss="modal">Create Vault</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <h2 class="">Hello {{user.username}}</h2>
        </div>
        <div v-if="toggleView">
            <h4>You are currently viewing your Keeps</h4>
            <keep></keep>
        </div>
        <div v-if="!toggleView">
            <h4>You are currently viewing your Vaults</h4>
            <vault></vault>
        </div>
    </div>
</template>

<script>
    import router from '../router'
    import Keep from './Keep'
    import Vault from './Vault'
    export default {
        name: 'UserProfile',
        components: {
            Keep,
            Vault
        },
        data() {
            return {
                newKeep: {
                    name: '',
                    img: '',
                    description: '',
                    vaultId: '',
                },
                newVault: {
                    name: '',
                    description: '',
                    userId: ''
                },
                toggleView: true
            }
        },
        mounted() {
            if (!this.$store.state.user._id) {
                router.push({ name: 'Home' })
            }
            this.$store.dispatch('getUserVaults', this.user)
        },
        computed: {
            user() {
                return this.$store.state.user;
            },
            userVaults() {
                return this.$store.state.userVaults;
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
            },
            createVault(newVault) {
                console.log(newVault)
                newVault.userId = this.$store.state.user.id
                this.$store.dispatch('createVault', newVault)
            },
            viewToggle() {
                console.log(this.$store.state.userVaults)
                this.toggleView = !this.toggleView
            }
        }
    }




</script>

<style>
</style>