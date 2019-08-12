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
          <input type="text" class="form-control ml-5" id="KeepName" placeholder="Keep Name" v-model="keep.name"
            style="width:25vw;">
          <input type="text" class="form-control ml-5" id="KeepDescription" placeholder="Keep Description"
            v-model="keep.description" style="width:25vw;">
          <input type="text" class="form-control ml-5" id="KeepImg" placeholder="Keep Image" v-model="keep.img"
            style="width:25vw;">
          <div class="ml-5 text-muted"
            style="float: left; border: 1px solid rgba(131, 130, 130, 0.459); width: 25vw; text-align:left; padding-left: 1vw;">
            Is
            Private?
            <input class="ml-2" type="checkbox" v-model="keep.isPrivate"></div>
          <button @click="makeNewKeep(keep)" class="button btn-success float-left ml-2">SUBMIT</button>
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
    },
    components: {
      userKeeps,
    }
  };
</script>

<style>

</style>