<template>
    <div>
        <div v-for="keep in keeps" :key="keep.id" class="card text-center">
            <h3 class="card-title">{{keep.name}}</h3>
            <div class="container">
                <img :src="keep.img" alt="">
                <div class="buttons">
                    <button class="btn" data-toggle="modal" data-target="#viewingKeepModal" @click="addView(keep)">View</button>
                    <button class="btn" @click="addToVault(keep)">Add to Vault </button>
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
                        <h5 class="modal-title">Keep: {{keep.name}}</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <select v-model="keep.vaultId">
                            <option disabled value="">Select a Vault</option>
                            <option v-for="vault in vaults" :key="vault.id" value="keep.vaultId">{{vault.name}}</option>
                        </select>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <button class="btn btn-primary btn-primary" @click="saveKeep" data-dismiss="modal">Save</button>
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
                    vaultId: ''                 
                }
            }
        },
        mounted() {
            this.$store.dispatch('getKeeps')
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            vaults() {
                return this.$store.state.vaults
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
            addToVault(vault) {
                console.log(vault)
            },
            saveKeep(keep) {
                console.log(keep)

            },
            addView(keep){
                keep.views ++
                this.$store.dispatch('updateKeep', keep)
            }
        }
    }

</script>

<style>
</style>