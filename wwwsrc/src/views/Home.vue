<template>
  <div class="home">
    <div class="row">
      <div class="col-12">
        <button class="button btn-success float-left ml-5 mt-5" @click="keepRedirect">Add new Keep</button>
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
      }
    },
    components: {
      publicKeeps
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