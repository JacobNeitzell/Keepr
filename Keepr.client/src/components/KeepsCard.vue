<template>
  <div class="Keep-Card">
    <div class="card text-dark  " v-if="keep">
      <img class="card-img forcedImg" :src="keep.img" alt="Card-Image" />
      <div class="card-img-overlay">
        <h5 class="card-title">{{ keep.name }}</h5>
        <p class="card-text">{{ keep.creator.imgUrl }}</p>
      </div>
    </div>
  </div>


</template>


<script>


import { Keep } from "../models/Keep.js";

export default {
  props: {
    keep: {
      type: Keep, required: true
    },
  },
  setup() {
    return {

    }
  }
}
</script>


<style lang="scss" scoped>
.forcedImg {
  height: 300px;
  width: auto;
  object-fit: cover;
}

.card:hover {
  filter: brightness(90%);
  transition: all 0.5s ease;
  box-shadow: rgba(223, 12, 132, 0.4) 5px 5px, rgba(88, 3, 101, 0.3) 10px 10px,
    rgba(175, 8, 138, 0.2) 15px 15px, rgba(60, 45, 6, 0.1) 20px 20px;
}
</style>