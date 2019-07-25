<template>
  <div class="userVaults">
    <h1>This is the userVaults component</h1>
    <ul>
      <li v-for="vault in vaults">
        <router-link :to="{name: 'Vault', params: {id: vault.id}}">{{vault.name}}</router-link><button
          @click="deletevault(vault.id)" class="button btn-danger">DELETE</button>
      </li>
      <!-- <router-link :to="{name: 'Keep', params: {id: userkeep.id}}">{{userkeep.name}}</router-link><button
                    @click="deleteKeep(userkeep.id)" class="button btn-danger">DELETE</button> -->
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