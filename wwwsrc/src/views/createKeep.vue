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
          <input type="text" class="form-control ml-5" id="KeepName" placeholder="Enter Keep Name: "
            v-model="newKeep.name" style="width:25vw;">
          <label class="ml-5 mr-3" style="float: left;" for="KeepDescription">Description: </label>
          <input type="text" class="form-control ml-5" id="KeepDescription" placeholder="Enter Keep Description: "
            v-model="newKeep.description" style="width:25vw;">
          <label class="ml-5 mr-3" style="float: left;" for="KeepImg">Image: </label>
          <input type="text" class="form-control ml-5" id="KeepImg" placeholder="Enter Keep Image: "
            v-model="newKeep.img" style="width:25vw;">
          <button @click="makeNewKeep" class="button btn-success">SUBMIT</button>
          <input type="submit">
        </div>
      </div>
    </div>

  </div>
</template>

<script>

  export default {
    name: "createKeep",
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      makeNewKeep() {
        debugger
        console.log(this.newKeep)
        this.$store.dispatch("makeNewKeep", this.newKeep);
      },
      // keepRedirect() {
      //   this.$router.push("createKeep")
      // }
    },
    components: {
      // publicKeeps
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