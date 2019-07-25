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
    userkeeps: [],
    uservaults: [],
    publicKeeps: {},
    keep: {}
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
    setUserKeeps(state, data) {
      state.userkeeps = data
    },
    setUserVaults(state, data) {
      state.uservaults = data
    },
    setSingleKeep(state, data) {
      state.keep = data
    }
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
        dispatch('getUserKeeps')
      } catch (error) {

      }
    },
    async deleteKeep({ commit, dispatch }, payload) {
      try {
        debugger
        let res = await api.delete('keeps/' + payload, payload)
        console.log(res)
        console.log("PAYLOAD CONFIRMATION: " + payload)
        dispatch('getUserKeeps')
      } catch (error) {

      }
    },
    async makeNewVault({ commit, dispatch }, payload) {
      try {
        let res = await api.post('vaults', payload)
        console.log(res)
        console.log("PAYLOAD CONFIRMATION: " + payload)
        // commit('setNewKeep', res.data)
      } catch (error) {

      }
    },
    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps/user')
        console.log(res)
        commit('setUserKeeps', res.data)
      } catch (error) {

      }
    },
    async deleteVault({ commit, dispatch }, payload) {
      try {
        let res = await api.delete('vaults/' + payload, payload)
        console.log(res)
        dispatch('getUserVaults')
      } catch (error) {

      }
    },
    async getUserVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults')
        console.log(res)
        commit('setUserVaults', res.data)
      } catch (error) {

      }
    },
    async getKeepById({ commit, dispatch }, payload) {
      try {
        let res = await api.get('keeps/' + payload, payload)
        dispatch("iterateKeepViews", res.data)
        commit('setSingleKeep', res.data)
        console.log(res)
      } catch (error) {

      }
    },
    async iterateKeepViews({ commit, dispatch }, payload) {
      try {
        let res = await api.put('keeps/')
      } catch (error) {

      }
    }
  }
})
