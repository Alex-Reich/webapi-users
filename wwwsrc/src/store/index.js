import vue from 'vue'
import vuex from 'vuex'
import axios from 'axios'
import router from '../router'
import { ESRCH } from 'constants';
import { debug } from 'util';


var production = !window.location.host.includes('localhost');
var baseUrl = production ? '' : '//localhost:5000/';


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
        keeps: [],
        userKeeps: [],
        vaults: [],
        activeVault: {}

    },
    mutations: {
        setUser(state, user) {
            state.user = user
        },
        deleteUser(state) {
            state.user = {}
        },
        setVaults(state, vaults) {
            state.vaults = vaults
        },
        setNewVault(state, vault) {
            state.vaults.unshift(vault)
        },
        setActiveVault(state, vault) {
            state.activeVault = vault
        },
        setKeeps(state, keeps) {
            state.keeps = keeps
        },
        setUserKeeps(state, keeps) {
            state.userKeeps = keeps
        },
        setNewKeep(state, keep) {
            state.userKeeps.unshift(keep)
        },
    },
    actions: {
        login({ commit }, loginCredentials) {
            auth.post('account/login', loginCredentials)
                .then(res => {
                    console.log('Successfully logged in')
                    console.log(res.data)
                    commit('setUser', res.data)
                })
                .catch(err => {
                    console.log("Invalid Credentials")
                })
        },
        logout({ commit }) {
            auth.delete('account/logout')
                .then(res => {
                    commit('deleteUser')
                    router.push({ name: 'Home' })
                })
        },
        register({ commit }, userData) {
            console.log(userData)
            auth.post('account/register', userData)
                .then(res => {
                    commit('setUser', res.data)
                    // router.push({ name: 'UserProfile' })
                })
        },
        authenticate({ commit, dispatch }, loginCredentials) {
            auth.get("account/authenticate").then(res => {
                commit("setUser", res.data)
            })
                .catch(err => {
                    console.log("Invalid Credentials")
                })
        },
        getKeeps({commit, dispatch, }) {
            api.get("api/keep")
            .then(res => {
                commit("setKeeps", res.data)
            })
            .catch(err =>{
                console.log(err)
            })
        },
        createKeep({ commit, dispatch }, keep) {
            api.post("api/keep/", keep)
                .then(res => {
                    commit("setKeeps", res.data)
                })
                .catch(err => {
                    console.log("Error creating keep")
                })
        }


    }
})  