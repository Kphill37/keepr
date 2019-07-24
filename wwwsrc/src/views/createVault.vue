<template>
  <div class="createVault">
    <h1>This is the createVault view</h1>
  </div>
</template>

<script>


  export default {
    name: "createVault",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      // logout() {
      //   this.$store.dispatch("logout");
      // },
      // keepRedirect() {
      //   this.$router.push("createKeep")
      // }
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