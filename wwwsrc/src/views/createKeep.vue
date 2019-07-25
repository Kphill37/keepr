<template>
  <div class="createKeep">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <h1 class="mt-5 ml-5 float-left">Keep creation page!</h1>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="form-group">
          <label class="ml-5 mr-5" style="float: left;" for="KeepName">Name: </label>
          <input type="text" class="form-control ml-5" id="KeepName" placeholder="Enter Keep Name: " v-model="keep.name"
            style="width:25vw;">
          <label class="ml-5 mr-3" style="float: left;" for="KeepDescription">Description: </label>
          <input type="text" class="form-control ml-5" id="KeepDescription" placeholder="Enter Keep Description: "
            v-model="keep.description" style="width:25vw;">
          <label class="ml-5 mr-3" style="float: left;" for="KeepImg">Image: </label>
          <input type="text" class="form-control ml-5" id="KeepImg" placeholder="Enter Keep Image: " v-model="keep.img"
            style="width:25vw;">
          <input type="checkbox" v-model="keep.isPrivate">
          <p>Is Private?</p>
          <button @click="makeNewKeep(keep)" class="button btn-success">SUBMIT</button>
        </div>
      </div>
    </div>

    <userKeeps />



  </div>
</template>

<script>
  import userKeeps from '@/components/userKeeps.vue'

  export default {
    name: "createKeep",
    data() {
      return {
        keep: {
          name: "",
          description: "",
          img: "",
          isPrivate: false,
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
    },
    methods: {
      makeNewKeep(keep) {
        this.$store.dispatch("makeNewKeep", keep);
      },
      // keepRedirect() {
      //   this.$router.push("createKeep")
      // }
    },
    components: {
      userKeeps,
    }
  };
</script>

<style>
  /* .navbar {
    height: 10vh;
  }

  .btn-danger {
    float: right;
  } */
</style>