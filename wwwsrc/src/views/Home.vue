<template>
  <div class="home">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">
        <h2>Keepr</h2>
      </a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav"
        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse w-100 order-3 dual-collapse2" id="navbarNav">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item active ">
            <h6 class="mb-0 mt-1">Welcome, {{user.username}}</h6>
            <h6 class="mb-0">My Vaults</h6>
            <h6 class="mb-0 mr-2" v-if="user.id" @click="logout">Logout</h6>
            <!-- <button class="button btn-danger mr-10" v-if="user.id" @click="logout">Logout</button> -->
            <router-link v-else :to="{name: 'login'}">Login</router-link>
          </li>
        </ul>
      </div>
    </nav>
    <div class="row">
      <div class="col-12">
        <button class="button btn-success float-left ml-5 mt-5">Add new Keep</button>
      </div>
    </div>



  </div>
</template>

<script>
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
      }
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