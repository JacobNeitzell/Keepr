<template>
  <div class="Keep-Card p-1" @click="setActiveKeep(keep)">
    <div class="card text-dark " v-if="keep" data-bs-target="#keeps-modal" data-bs-toggle="modal">
      <img class="card-img" :src="keep.img" alt="Card-Image" />
      <div class="card-img-overlay">
        <h5 class="card-title">{{ keep.name }}</h5>
        <p class="card-text"></p>
      </div>
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
</style>