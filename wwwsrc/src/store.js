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
    keep: {},
    vault: {},
    vaultkeeps: [],
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
    },
    setSingleVault(state, data) {
      state.vault = data
    },
    setVaultKeeps(state, data) {
      state.vaultkeeps = data
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
        commit('setPublicKeeps', res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async makeNewKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.post('keeps', payload)
        dispatch('getUserKeeps')
      } catch (error) {
        console.log(error)
      }
    },
    async deleteKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.delete('keeps/' + payload, payload)
        dispatch('getUserKeeps')
      } catch (error) {
        console.log(error)
      }
    },
    async makeNewVault({ commit, dispatch }, payload) {
      try {
        let res = await api.post('vaults', payload)
        // commit('setNewKeep', res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps/user')
        commit('setUserKeeps', res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async deleteVault({ commit, dispatch }, payload) {
      try {
        let res = await api.delete('vaults/' + payload, payload)
        dispatch('getUserVaults')
      } catch (error) {
        console.log(error)
      }
    },
    async getUserVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults')
        commit('setUserVaults', res.data)
      } catch (error) {

      }
    },
    async getKeepById({ commit, dispatch }, payload) {
      try {
        let res = await api.get('keeps/' + payload, payload)
        commit('setSingleKeep', res.data)
      } catch (error) {

      }
    },
    async updateKeepCount({ commit, dispatch }, payload) {
      payload.views++
      console.log(payload)
      try {
        let res = await api.put('keeps/' + payload.id, payload)
      } catch (error) {

      }
    },
    async iterateKeepCount({ commit, dispatch }, payload) {
      console.log("KEEP COUNT" + payload.keeps)
      payload.keeps++
      console.log("KEEP COUNT" + payload.keeps)
      try {
        let res = await api.put('keeps/' + payload.id, payload)
      } catch (error) {

      }
    },
    async clearSingleKeep({ commit, dispatch }) {
      commit('setSingleKeep', {})
    },
    async getVaultById({ commit, dispatch }, payload) {
      try {
        let res = await api.get('vaults/' + payload, payload)
        commit('setSingleVault', res.data)
      } catch (error) {

      }
    },
    async getVaultKeeps({ commit, dispatch }, payload) {
      try {
        let res = await api.get('vaultkeeps/' + payload, payload)
        commit('setVaultKeeps', res.data)
      } catch (error) {

      }
    },
    async addVaultKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.post('vaultkeeps/', payload)
      } catch (error) {

      }
    },
    async deleteVaultKeep({ commit, dispatch }, payload) {
      try {
        let res = await api.put('vaultkeeps/' + payload.vaultid, payload)
        dispatch("getVaultKeeps", payload.vaultid)
      } catch (error) {

      }
    }
  }
})
