<template>
  <div class="publicKeeps">
    <div class="card mt-2 ml-2" v-if="!keep.isPrivate" v-for="keep in keeps"
      style="width: 18rem; max-height: 15rem; min-height: 15rem;">
      <img class="card-img-top">
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        <p class="card-text">{{keep.description}}</p>
      </div>
    </div>

  </div>
</template>


<script>

  export default {
    name: "publicKeeps",
    props: [],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getPublicKeeps")
    },
    computed: {
      keeps() {
        return this.$store.state.publicKeeps
      }
    },

    methods: {

    },
    components: {

    }
  }


</script>


<style>


</style>