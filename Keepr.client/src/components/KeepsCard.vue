<template>
  <div class="Keep-Card">
    <span data-bs-target="#KeepModal" data-bs-toggle="modal"> </span>
    <div class="card text-dark  " v-if="keep">
      <img class="card-img" :src="keep.img" alt="Card-Image" />
      <div class="card-img-overlay">
        <h5 class="card-title">{{ keep.name }}</h5>
        <p class="card-text"></p>
      </div>
    </div>
  </div>


</template>


<script>


import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";

export default {
  props: {
    keep: {
      type: Keep, required: true
    },
  },
  setup(props) {
    return {


      setActiveKeep() {
        keepsService.setActiveKeep(props.keep)
      }





    }

  }
}
</script>


<style lang="scss" scoped>
.card:hover {
  filter: brightness(90%);
  transition: all 0.5s ease;
  box-shadow: rgba(223, 12, 132, 0.4) 5px 5px, rgba(88, 3, 101, 0.3) 10px 10px,
    rgba(175, 8, 138, 0.2) 15px 15px, rgba(60, 45, 6, 0.1) 20px 20px;
}
</style>