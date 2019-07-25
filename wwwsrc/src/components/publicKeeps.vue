<template>
  <div class="publicKeeps container w90">
    <div class="row">
      <div class="card col-4 mt-2 ml-2" v-if="!keep.isPrivate" v-for="keep in keeps">
        <img class="card-img-top">
        <div class="card-body" style="min-height: 18rem;">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <img :src="keep.img" alt="">
          <select v-model="selected" @change="addVaultKeep(keep)">
            <option disabled value>Add To Vault</option>
            <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
          </select>
        </div>
      </div>
    </div>
  </div>
</template>


<script>

  export default {
    name: "publicKeeps",
    props: [],
    data() {
      return {
        selected: ""
      }
    },
    mounted() {
      this.$store.dispatch("getPublicKeeps")
      this.$store.dispatch("getUserVaults")
    },
    computed: {
      keeps() {
        return this.$store.state.publicKeeps
      },
      vaults() {
        return this.$store.state.uservaults
      }
    },

    methods: {
      addVaultKeep(keep) {
        let vaultid = this.selected
        let keepid = keep.id
        this.$store.dispatch("addVaultKeep", { keepid, vaultid })
        this.selected = ''
      }
    },
    components: {

    }
  }


</script>


<style>


</style>