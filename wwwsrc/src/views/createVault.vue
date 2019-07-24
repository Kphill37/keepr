<template>
  <div class="createVault">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <div class="form-group">
            <label class="ml-5 mr-5" style="float: left;" for="vaultName">Name: </label>
            <input type="text" class="form-control ml-5" id="VaultName" placeholder="Enter Vault Name: "
              v-model="vault.name" style="width:25vw;">
            <label class="ml-5 mr-3" style="float: left;" for="vaultDescription">Description: </label>
            <input type="text" class="form-control ml-5" id="vaultDescription" placeholder="Enter Vault Description: "
              v-model="vault.description" style="width:25vw;">
            <button @click="makeNewVault(vault)" class="button btn-success">SUBMIT</button>

          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>


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
        console.log(vault)
        this.$store.dispatch("makeNewVault", vault);
      },
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