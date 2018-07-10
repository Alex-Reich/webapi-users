import vue from 'vue'
import vuex from 'vuex'
import axios from 'axios'
import router from '../router'


var production = !window.location.host.includes('localhost');
var baseUrl = production ? '' : '//localhost:3000/';


vue.use(vuex)

var api = axios.create({
    baseURL: baseUrl,
    timeout: 3000,
    withCredentials: true
  })
  var auth = axios.create({
    baseURL: baseUrl + 'auth/',
    timeout: 3000,
    withCredentials: true
  })

export default new vuex.Store({
    state: {
        user: {},
        pins: [],
        boards: []
    },
    mutations: {
        setUser(state, user){
            state.user = user
        },
        deleteUser(state){
            state.user = {}
        }
    },
    actions: {
        login({commit}, loginCredentials){
            auth.post('login', loginCredentials)
            .then(res => {
                console.log('Successfully logged in')
                console.log(res.data)
                commit('setUser', res.data.data)
            })
            .catch(err => {
                console.log("Invalid Credentials")
            })
        },
        authenticate({commit, dispatch}, loginCredentials){
            auth.get("authenticate").then(res => {
                commit("setUser", res.data)
            })
            .catch(err => {
                console.log("Invalid Credentials")
            })
        }
    }
})  