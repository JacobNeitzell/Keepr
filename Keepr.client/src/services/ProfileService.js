import { AppState } from "../AppState.js"
import { Account } from "../models/Account.js"
import { Keep } from "../models/Keep.js"
import { Profile } from "../models/Profile.js"
import { api } from "./AxiosService.js"

class ProfileService {

  async GetDProfileId(id) {
    const res = await api.get('api/profile/' + id)
    AppState.profile = new Profile(res.data)
    return res.data
  }

  async SetActiveProfile(creatorId) {
    AppState.ActiveProfile = creatorId;
    const res = await api.get(`profile/${profileId}`)
  }



}
export const profileService = new ProfileService