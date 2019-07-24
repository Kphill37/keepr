<template>
  <div class="userVaults">
    <h1>This is the userVaults component</h1>
  </div>
</template>

<script>


  export default {
    name: "userVaults",
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