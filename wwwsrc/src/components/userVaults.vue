<template>
  <div class="userVaults">
    <h1>This is the userVaults component</h1>
    <ul>
      <li v-for="vault in vaults">new vault <button @click="deletevault(vault.id)"
          class="button btn-danger">DELETE</button></li>
    </ul>
  </div>
</template>

<script>


  export default {
    name: "userVaults",
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.uservaults
      }
    },
    mounted() {
      this.$store.dispatch("getUserVaults")
    },
    methods: {
      deletevault(id) {
        this.$store.dispatch("deleteVault", id)
      }
    },
    components: {

    }
  };
</script>

<style>
  .navbar {
    height: 10vh;
  }

  .btn-danger {
    float: right;
  }
</style>