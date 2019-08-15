<template>
  <div class="vaultKeeps mt-2 ml-3 container-fluid w100">
    <div v-if="vaultkeeps.length == 0">
      <h1>No Keeps in this vault yet!</h1>
    </div>
    <div class="row">
      <div class="card col-lg-3 col-md-12 mb-5 mt-2 ml-2" v-for="keep in vaultkeeps">
        <img class="card-img-top">
        <div class="card-body" style="min-height: 18rem;">
          <h5 class="card-title pt-1">{{keep.name}}<br>
            <h6 style="font-size: 1rem">Views: {{keep.views}}</h6>
          </h5>
          <p class="card-text">{{keep.description}}</p>
          <img :src="getKeepImg(keep)" alt="Keep Image">
          <i class="fas fa-eye mr-5 mt-5" @click="viewKeep(keep)">View</i>
          <button @click="removeVaultKeep(keep)" class="button btn-danger mt-5">Delete From Vault</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

  export default {
    name: "Vault",
    props: [],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getVaultById", this.$route.params.id)

      if (this.vault) {
        this.$store.dispatch("getVaultKeeps", this.$route.params.id)
      }
    },
    computed: {
      vault() {
        return this.$store.state.vault
      },
      vaultkeeps() {
        return this.$store.state.vaultkeeps
      }
    },

    methods: {
      removeVaultKeep(keep) {
        let vaultid = this.$route.params.id
        let keepid = keep.id
        this.$store.dispatch("deleteVaultKeep", { vaultid, keepid })
        this.$store.dispatch("getVaultKeeps", this.$route.params.id)
      },
      viewKeep(keep) {
        this.$store.dispatch("updateKeepCount", keep)
        this.$router.push({ name: 'Keep', params: { id: keep.id } })
      },
      getKeepImg(keep) {
        if (!keep.img) {
          return defaultIMG
        }
        return keep.img
      },
    },
    components: {

    }
  }


</script>


<style>
  .btn-danger {
    margin-right: 2rem;
    margin-bottom: 1vh;
  }
</style>