<template>
  <div class="VaultView">
    <h1>VaultView: </h1>{{vault.views}}
  </div>
</template>

vaultkeeps/:vaultId
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