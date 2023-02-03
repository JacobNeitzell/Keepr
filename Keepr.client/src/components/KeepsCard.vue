<template>
  <!-- <div class="Keep-Card p-1" @click="setActiveKeep(keep)">
    <div class="card text-dark " v-if="keep" data-bs-target="#keeps-modal" data-bs-toggle="modal">

      <img class="card-img" :src="keep.img" alt="Card-Image" />
      <div class="card-img-overlay">
        <h5 class="card-title text-shadow">{{ keep.name }}</h5>
        <p class="card-text"></p>
      </div>
    </div>

  </div> -->

  <div class="card border-0  rounded position-relative selectable p-1" @click="setActiveKeep(keep)" :title="keep?.name">
    <img :src="keep?.img" :alt="keep.name" class="card-img img-fluid rounded img" alt="" />
    <div class="card-img-overlay align-items-end d-flex justify-content-between text-shadow ">
      <h5 class="card-title no-select">{{ keep?.name }}</h5>
      <img :src="keep.creator?.picture" class="person rounded-circle" :title="keep.creator?.name"
        :alt="keep.creator.name" height="40" width="40" />
    </div>
  </div>

</template>


<script>


import { computed } from "@vue/reactivity";
import { Modal } from "bootstrap";
import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";
import { profileService } from "../services/ProfileService.js";
import Pop from "../utils/Pop.js";


export default {
  props: {
    keep: {
      type: Keep,
      required: true
    },
  },
  setup(props) {
    return {
      creator: computed(() => AppState.account.id == props.keep.id),
      async setActiveKeep(keep) {
        try {
          await keepsService.setActiveKeep(keep);
          Modal.getOrCreateInstance('#keeps-modal').show()
        }
        catch (error) {
          Pop.error(error);
        }
      }
    };
  },
  async SetActiveProfile() {
    try {
      profileService.SetActiveProfile(props.creator)
    } catch (error) {
      Pop.error(error);
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


.text-shadow {
  color: rgb(33, 2, 2);
  text-shadow: 1px 1px rgb(113, 91, 91), 0px 0px 5px rgb(140, 28, 158);
  font-weight: bold;
  letter-spacing: 0.08rem
}
</style>