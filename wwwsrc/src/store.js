import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    publicKeeps: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    // setNewKeep(state, data) {
    //   state.
    // }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
      //#endregion

      //#region -- site functionality
    },
    async getPublicKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps')
        console.log(res)
        commit('setPublicKeeps', res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async makeNewKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.post('keeps', payload)
        console.log(res)
        console.log("PAYLOAD CONFIRMATION: " + payload)
        // commit('setNewKeep', res.data)
      } catch (error) {

      }
    }
  }
})
