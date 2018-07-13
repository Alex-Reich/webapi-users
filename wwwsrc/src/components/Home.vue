<template>
  <div class="home">
    <h1>Welcome to Keepr</h1>
    <div v-if="!loggedIn">
      <button type="button" class="btn btn1 mt-1 btnwidth2 mr-4" data-toggle="modal" data-target="#loginModal">Login</button>
      <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel">Login</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form v-on:submit.prevent="userLogin">
                <div class="form-group">
                  <input type="text" name="email" v-model="
                  login.email" class="form-control" id="formGroupExampleInput" placeholder="Email" required>
                </div>
                <div class="form-group">
                  <input type="text" name="password" v-model="
                  login.password" class="form-control" id="formGroupExampleInput" placeholder="Password">
                </div>
                <button type="button" @click="userLogin" class="btn btn1" data-dismiss="modal">Login</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
              </form>
            </div>
          </div>
        </div>
      </div>

      <!-- Register Modal -->
      <button type="button" class="btn btn1 mt-1 btnwidth2 ml-4" data-toggle="modal" data-target="#registerModal">Register</button>
      <div class="modal fade" id="registerModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel">Register</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form v-on:submit.prevent="userRegister">
                <div class="form-group">
                  <input type="text" name="username" v-model="register.username" class="form-control" id="formGroupExampleInput" placeholder="Username"
                    required>
                </div>
                <div class="form-group">
                  <input type="text" name="email" v-model="register.email" class="form-control" id="formGroupExampleInput" placeholder="Email">
                </div>
                <div class="form-group">
                  <input type="text" name="password" v-model="register.password" class="form-control" id="formGroupExampleInput" placeholder="Password">
                </div>
                <button type="button" @click="userRegister" class="btn btn1" data-dismiss="modal">Register</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
              </form>
            </div>
          </div>
        </div>
      </div>

    </div>
        <div v-if="loggedIn">
          <UserProfile></UserProfile>
        </div>
    <div>
      <Keep></Keep>
    </div>

  </div>
</template>

<script>
  import router from '../router'
  import UserProfile from './UserProfile'
  import Keep from './Keep'
  export default {
    name: 'Home',
    components: {
      UserProfile,
      Keep
    },
    data() {
      return {
        login: {
          email: '',
          password: ''
        },
        register: {
          username: '',
          email: '',
          password: '',
        }
      }
    },
    mounted() {
      if (!this.$store.state.user._id) {
        this.$store.dispatch('authenticate')
      }
      // this.$store.dispatch('getAllKeeps')
    },
    computed: {
      loggedIn() {
        return this.$store.state.loggedIn
      }
    },
    methods: {
      userLogin() {
        this.$store.dispatch('login', this.login)
        this.$store.state.loggedIn = true
      },
      userRegister() {
        this.$store.dispatch('register', this.register)
      },
      getKeeps() {
        this.$store.dispatch('getKeeps', this.search)
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>