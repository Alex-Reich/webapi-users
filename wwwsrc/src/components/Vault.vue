<template>
  <div class="">
    <div v-for="vault in userVaults" v-if="vault.userId == user.id" :key="vault.id" class="card text-center">
      <div @click="setActiveVault(vault)">
        <h3 class="card-title">{{vault.id}}. {{vault.name}}</h3>
        <h3 class="card-text">Description: {{vault.description}}</h3>
        <div v-if="activeVault == vault">
          draw the vaultKeeps

          <div v-for="keep in keeps" v-if="keep.public == 1 " :key="keep.id" class="card text-center">
            <h3 class="card-title">{{keep.id}}. {{keep.name}}</h3>
            <div class="container">
              <img :src="keep.img" alt="">
              <div class="buttons">
                <button class="btn" @click="addView(keep)">View</button>
                <div v-if="user.id == keep.userId && keep.public == 0">
                  <button class="btn btn-danger" @click="deleteKeep(keep)">Delete</button>
                </div>
              </div>
              <h3 class="card-text">Description: {{keep.description}}</h3>
              <h3 class="card-text">Views: {{keep.views}} Saves: {{keep.saves}}</h3>
            </div>
          </div>
        </div>
        <button class="btn btn-danger" @click="deleteVault(vault)">Delete Vault</button>
        <div class="container">



          <!-- View Keep Modal -->
          <div class="modal fade" id="viewingAKeepModal" tabindex="-1" role="dialog" aria-labelledby="viewingKeepModalTitle" aria-hidden="true">
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
                      <select v-model="keep.vaultId">
                        <option disabled value="">Select a Vault</option>
                        <option v-for="vault in userVaults" :key="vault.id" value="vault">{{vault.name}}</option>
                      </select>
                    </div>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" @click="updateKeep(keep)" data-dismiss="modal">Save</button>
                  </div>
                </form>
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
        },
        viewKeep: {},
        activeVault: {}
      }
    },
    mounted() {
      this.$store.dispatch('getUserVaults', this.user)
      //this.$store.dispatch('getVaultKeeps', activeVault.id)
      console.log(this.user)
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      userVaults() {
        return this.$store.state.userVaults
      },
      keeps() {
        return this.$store.state.keeps
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {
      updateKeep(keep) {
        keep.saves++
        console.log(keep)
        this.$store.dispatch('updateKeep', keep)
        console.log("Keep updated", keep)
      },
      addView(keep) {
        keep.views++
        this.$store.dispatch('updateKeep', keep)
        this.viewKeep = keep
        $('#viewingAKeepModal').modal('show')
      },
      deleteVault(vault) {
        this.$store.dispatch("deleteVault", vault)
      },
      deleteKeep(keep) {
        this.$store.dispatch("deleteKeep", keep)
      },
      setActiveVault(vault) {
        this.activeVault = vault;
        debugger
        this.$store.dispatch("getVaultKeeps", this.activeVault);
      }
    }
  }

</script>

<style>
</style>