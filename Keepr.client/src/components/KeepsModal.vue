<template>
  <div class="KeepModal">
    <div class="modal" tabindex="-1" aria-labelledby="Label" aria-hidden="true" id="KeepModal">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <span>views and kept</span>
            <h5 class="modal-img">
              <image />
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <h2>TITLE</h2>
          <h5>Description</h5>
          <div class="modal-body">
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





  </div>
</template>


<script>
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { keepsservice } from "../services/KeepsService.js."
import Pop from "../utils/Pop.js";
export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {

    async function getKeepById() {
      try {
        if (AppState.activeKeep) {
          let keepId = AppState.activeKeep.id;
          await keepsservice.getKeepById(keepId);
        }
      } catch (error) {
        Pop.error(error)
      }
    }


    watchEffect(() => {
      AppState.activeKeep;
      getKeepById();
    })
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>