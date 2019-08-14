<template>
  <div class="userVaults">
    <h1>My Vaults: </h1>
    <div class="row">
      <div class="col-lg-12 w-75">
        <ul class="list-group">
          <li v-for="vault in vaults" class="list-group-item" @click="goToVault(vault)">{{vault.name}}
          </li>
        </ul>
      </div>
    </div>
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
      },
      goToVault(vault) {
        this.$router.push({ name: 'Vault', params: { id: vault.id } })
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

  .list-group-item {
    width: 80vw;
    margin: 0 auto;
    cursor: pointer;
    font-weight: bold;
    font-size: 2rem
  }
</style>