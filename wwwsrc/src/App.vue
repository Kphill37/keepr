<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">
        <router-link style="color: black;" :to="{name: 'home'}">
          <h2>Keepr</h2>
        </router-link>

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
    <router-view />
  </div>
</template>

<script>
  import publicKeeps from '@/components/publicKeeps.vue'

  export default {
    name: "App",
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
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>