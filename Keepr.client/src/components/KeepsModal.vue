<template>

  <div class="modal" tabindex="-1" aria-labelledby="Label" aria-hidden="true" id="KeepModal">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <span>{{ keep.views }} {{ keep.kept }}</span>
          <h5 class="modal-img">
            <image :src="keep.img" />
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body" v-if="keep">
          <h2>{{ keep.name }}</h2>
          <h5>{{ keep.description }}</h5>
          <span>Vault Saves</span>
          <div>
            User Picture and name
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-primary">Save Vault button</button>

        </div>
      </div>
    </div>
  </div>






</template>


<script>
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {

    watchEffect(() => {
      AppState.activeKeep;
    })
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>