import { Account } from "./Account.js"
import { Profile } from "./Profile.js"

export class Vault {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.isPrivate = data.isPrivate || false
    this.creator = new Profile(data.creator)
  }
}