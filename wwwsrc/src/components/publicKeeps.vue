<template>
  <div class="publicKeeps">
    <div class="card mt-2 ml-2" v-if="!keep.isPrivate" v-for="keep in keeps"
      style="width: 18rem; max-height: 15rem; min-height: 15rem;">
      <img class="card-img-top">
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-text">{{keep.description}}</p>
        <p>ADD TO VAULT</p>
        <select v-model="selected" @change="addVaultKeep(keep, vault)">
          <option disabled value>Add To Vault</option>
          <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
        </select>
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
      addVaultKeep(keep, vault) {
        debugger
        vaultid = this.vault.id
        this.$store.dispatch("addVaultKeep", keep, vaultid)
      }
    },
    components: {

    }
  }


</script>


<style>


</style>