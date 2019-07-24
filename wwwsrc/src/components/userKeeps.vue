<template>
  <div class="userKeeps">

    <h1>UserKeeps Component</h1>
    <ul>
      <li v-for="userkeep in userKeeps" :value="Id">{{userkeeps.name}}</li>
    </ul>
  </div>
</template>

<script>


  export default {
    name: "userKeeps",
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getUserKeeps");
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      userKeeps() {
        return this.$store.state.userKeeps
      }
    },
    methods: {

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