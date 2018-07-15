<template>
  <div class="">
    <h1>This is where I will draw my vaults</h1>
    <div v-for="vault in userVaults" :key="vault.id" class="card text-center">
      <h3 class="card-title">{{vault.name}}</h3>
      <h3 class="card-text">Description: {{vault.description}}</h3>
      <div class="container">
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
        <button class="btn" data-toggle="modal" data-target="#viewingKeepModal" @click="addView(keep)">View</button>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
  export default {
    name: 'Vault',
    data() {
      return {

      }
    },
    mounted() {},
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
    methods: {}
  }

</script>

<style>
</style>