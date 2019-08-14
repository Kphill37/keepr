<template>
  <div class="createVault">
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-12">
          <div class="form-group">
            <input type="text" class="form-control ml-5" id="VaultName" placeholder="Enter Vault Name"
              v-model="vault.name">
            <input type="text" class="form-control ml-5" id="vaultDescription" placeholder="Enter Vault Description: "
              v-model="vault.description"> <button v-on:submit.prevent="onSubmit" @click="makeNewVault(vault)"
              class="button btn-success float-center">SUBMIT</button>
          </div>

        </div>
      </div>
    </div>

    <userVaults />

  </div>
</template>

<script>
  import userVaults from '@/components/userVaults.vue'


  export default {
    name: "createVault",
    data() {
      return {
        vault: {
          name: "",
          description: "",
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      makeNewVault(vault) {
        this.$store.dispatch("makeNewVault", vault);
      },
    },
    components: {
      userVaults
    }
  };
</script>

<style scoped>
  .navbar {
    height: 10vh;
  }

  .btn-danger {
    float: right;
  }

  .form-group {
    width: 50vw;
    margin-top: 10vh;
  }

  .list-group-item {
    width: 80vw;
    margin: 0 auto;
    cursor: pointer;
    font-weight: bold;
    font-size: 2rem
  }

  .btn-success {
    margin-left: 55vw;
  }
</style>