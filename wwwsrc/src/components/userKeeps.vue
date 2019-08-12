<template>
  <div class="userKeeps">
    <h1>My Keeps: </h1>
    <div class="row">
      <div class="col-lg-12 w-75">
        <ul class="list-group">
          <li v-for="userkeep in userKeeps" class="list-group-item" @click="goToKeep(userkeep)">{{userkeep.name}}</li>
        </ul>
      </div>
    </div>







    <!-- <ul>
      <li v-for="userkeep in userKeeps">
        <router-link :to="{name: 'Keep', params: {id: userkeep.id}}">{{userkeep.name}}</router-link><button
          @click="deleteKeep(userkeep.id)" class="button btn-danger">DELETE</button>
      </li>
    </ul> -->
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
        return this.$store.state.userkeeps
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      },
      goToKeep(keep) {
        this.$store.dispatch("updateKeepCount", keep)
        this.$router.push({ name: 'Keep', params: { id: keep.id } })
      }
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

  .list-group-item {
    margin: 0 auto;
  }
</style>