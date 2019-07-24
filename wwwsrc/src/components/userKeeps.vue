<template>
  <div class="userKeeps">
    <h1>This is the userKeeps component</h1>
  </div>
</template>

<script>


  export default {
    name: "userKeeps",
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


</style>