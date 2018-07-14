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
            
        }
    }

</script>

<style>
</style>