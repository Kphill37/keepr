<template>
  <div class="VaultView">
    <h1>VaultView: </h1>{{vault.views}}
    <ul>
      <li v-for="vaultkeep in vaultkeeps">
        {{vaultkeep}}
      </li>
    </ul>
  </div>
</template>

<script>

  export default {
    name: "Vault",
    props: [],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getVaultById", this.$route.params.id)

      if (this.vault) {
        debugger
        this.$store.dispatch("getVaultKeeps", this.$route.params.id)
      }
    },
    computed: {
      vault() {
        return this.$store.state.vault
      },
      vaultkeeps() {
        return this.$store.state.vaultkeeps
      }
    },

    methods: {

    },
    components: {

    }
  }


</script>


<style>


</style>