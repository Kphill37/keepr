<template>
  <div class="createVault">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <div class="form-group">
            <input type="text" class="form-control ml-5" id="VaultName" placeholder="Enter Vault Name"
              v-model="vault.name" style="width:25vw;">
            <input type="text" class="form-control ml-5" id="vaultDescription" placeholder="Enter Vault Description: "
              v-model="vault.description" style="width:25vw;">
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

<style>
  .navbar {
    height: 10vh;
  }

  .btn-danger {
    float: right;
  }
</style>