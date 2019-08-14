<template>
  <div class="userKeeps">
    <h1>My Keeps: </h1>
    <div class="row">
      <div class="col-lg-12 w-75">
        <ul class="list-group align-items-left">
          <li v-for="userkeep in userKeeps" class="list-group-item" @click="goToKeep(userkeep)">{{userkeep.name}}
            <img id="userkeep" :src="userkeep.img" alt=""></li>
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

<style scoped>
  .navbar {
    height: 10vh;
  }

  .btn-danger {
    float: right;
  }

  .list-group-item {
    width: 80vw;
    margin: 0 auto;
    cursor: pointer;
    float: left;
  }

  #userkeep {
    height: 75px;
    width: 75px;
    margin-left: 5vw;
  }
</style>