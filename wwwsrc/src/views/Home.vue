<template>
  <div class="home">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <button class="button btn-success float-left ml-5 mt-5" @click="keepRedirect">Keep Dashboard</button>
        </div>
        <div class="col-12">
          <button class="button btn-success float-left ml-5 mt-1" @click="vaultRedirect">Vault Dashboard</button>
        </div>
      </div>
    </div>
    <publicKeeps />
  </div>
</template>

<script>
  import publicKeeps from '@/components/publicKeeps.vue'

  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      keepRedirect() {
        this.$router.push("createKeep")
      },
      vaultRedirect() {
        this.$router.push("createVault")
      }
    },
    components: {
      publicKeeps
    }
  };
</script>

<style>
  .btn-danger {
    float: right;
  }

  body {}
</style>