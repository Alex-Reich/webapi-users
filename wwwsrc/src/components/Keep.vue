<template>
    <div >
        <div v-for="keep in keeps" :key="keep.id" class="card text-center">
            <h3 class="card-title">{{keep.name}}</h3>
            <div class="container">
                <img :src="keep.img" alt="">
                <div class="buttons">
                    <button class="btn" @click="viewKeep(keep)">View</button>
                    <button class="btn" @click="addtoVault(keep)">Add to Vault </button>
                </div>
            </div>
            <h3 class="card-text">Description: {{keep.description}}</h3>
            <h3 class="card-text">Views: {{keep.views}} Saves: {{keep.saves}}</h3>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Keep',
        data() {
            return {
                
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
        }
    }

</script>

<style>
</style>