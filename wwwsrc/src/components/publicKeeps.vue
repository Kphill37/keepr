<template>
  <div class="publicKeeps mt-2 container-fluid w50">
    <div class="row">
      <div class="card col-lg-4 col-md-12 mb-5 mt-2 ml-2" v-if="!keep.isPrivate" v-for="keep in keeps">
        <img class="card-img-top">
        <div class="card-body" style="min-height: 18rem;">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <img class="max-height: 18rem;" :src="getKeepImg(keep)" alt=""> <br>
          <div class="row">
            <div class="col-lg-12 col-md-12 mt-5">
              <select class="mb-5" v-model="selected" @change="addVaultKeep(keep)">
                <option disabled value>Add To Vault</option>
                <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
              </select>
            </div>
          </div>

        </div>
        <div class="row keepControls">
          <div class="col-lg-12 col-md-12">
            <i class="fas fa-eye mr-6" @click="viewKeep">View</i> <i class="fas fa-share mr-6">Share</i> <i
              class="fas fa-heart mr-3">Keep</i>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>

  import defaultIMG from '@/assets/200x200.png'

  export default {
    name: "publicKeeps",
    props: [],
    data() {
      return {
        selected: ""
      }
    },
    mounted() {
      this.$store.dispatch("getPublicKeeps")
      this.$store.dispatch("getUserVaults")
    },
    computed: {
      keeps() {
        return this.$store.state.publicKeeps
      },
      vaults() {
        return this.$store.state.uservaults
      }
    },

    methods: {
      addVaultKeep(keep) {
        let vaultid = this.selected
        let keepid = keep.id
        this.$store.dispatch("addVaultKeep", { keepid, vaultid })
        this.selected = ''
      },
      getKeepImg(keep) {
        if (!keep.img) {
          return defaultIMG
        }
        return keep.img
      },
      viewKeep() {
        console.log("Keep viewed!")
      }
    },
    components: {

    }
  }


</script>


<style>
  .card {
    border: 1px groove black;
  }

  .card-title {
    background-color: rgb(102, 183, 250);
    height: 7vh;
  }

  .fas {
    margin-right: 3vw;
    margin-bottom: 2vh;
  }
</style>