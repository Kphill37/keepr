<template>
  <div class="createKeep mt-7">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <h1 class="mt-5 ml-5 float-left">Create New Keep</h1>
        </div>
      </div>
    </div>
    <div class="form-row">
      <div class="col-lg-12">
        <div class="form-group">
          <input type="text" maxlength="20" class="form-control ml-5" id="KeepName" placeholder="Name"
            v-model="keep.name">
          <input type="text" maxlength="255" class="form-control ml-5" id="KeepDescription" placeholder="Description"
            v-model="keep.description">
          <input type="text" maxlength="255" class="form-control ml-5" id="KeepImg" placeholder="Image(url)"
            v-model="keep.img">
          <div class="ml-5 text-muted"
            style="float: left; border: 1px solid rgba(131, 130, 130, 0.459); width: 50vw; text-align:left; padding-left: 1vw;">
            Is
            Private?
            <input class="ml-2" type="checkbox" v-model="keep.isPrivate"></div>

        </div>
        <button v-on:submit.prevent="onSubmit" @click="makeNewKeep(keep)"
          class="button btn-success float-left ml-2">SUBMIT</button>
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
    },
    components: {
      userKeeps,
    }
  };
</script>

<style>
  .form-group {
    width: 50vw;
  }

  .btn-success {
    margin-bottom: 2vh;
  }

  button {
    margin: -20px auto;
  }
</style>