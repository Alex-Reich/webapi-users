<template>
  <div class="">
    <div v-for="vault in userVaults" :key="vault.id" class="card text-center">
      <h3 class="card-title">{{vault.id}}. {{vault.name}}</h3>
      <h3 class="card-text">Description: {{vault.description}}</h3>
      <button class="btn btn-danger" @click="deleteVault(vault)">Delete</button>
      <div class="container">

        <div v-for="keep in keeps" :key="keep.id" class="card text-center">
          <h3 class="card-title">{{keep.id}}. {{keep.name}}</h3>
          <div class="container">
            <img :src="keep.img" alt="">
            <div class="buttons">
              <button class="btn" data-toggle="modal" data-target="#viewingKeepModal" @click="addView(keep)">View</button>
              <button class="btn" @click="addToVault(keep)">Add to Vault </button>
              <button class="btn btn-danger" @click="deleteKeep(keep)">Delete</button>
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
                <div class="modal-body">
                  <div class="container">
                    <img :src="keep.img" alt="">
                    <h3 class="card-text">Description: {{keep.description}}</h3>
                    <h3 class="card-text">Views: {{keep.views}} Saves: {{keep.saves}}</h3>
                  </div>
                  <select v-model="keep.vaultId">
                    <option disabled value="">Select a Vault</option>
                    <option v-for="vault in userVaults" :key="vault.id" value="keep.vaultId">{{vault.name}}</option>
                  </select>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                  <button class="btn btn-primary btn-primary" @click="updateKeep" data-dismiss="modal">Save</button>
                </div>
              </div>
            </div>
          </div>
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
        keep: {
          vaultId: ''
        }
      }
    },
    mounted() { },
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
        console.log(keep)
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