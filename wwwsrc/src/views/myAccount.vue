<template>
  <div class="myAccount">

    <userVaults />
    <userKeeps />

  </div>
</template>

<script>
  import userVaults from '@/components/userVaults.vue'
  import userKeeps from '@/components/userKeeps.vue'


  export default {
    name: "myAccount",
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
      userVaults,
      userKeeps,
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