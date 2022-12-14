import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Account.js').Account | null} */
  ActiveProfile: null,
  /** @type {import('./models/Profile.js').Profile} */
  profile: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  keep: [],
  /** @type {import('./models/Keep.js').Keep[] } */
  views: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  kept: [],
  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,
  /** @type {import('./models/Keep.js').Keep[]} */
  myKeep: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  profileKeep: [],
  /** @type {import('./models/Vault.js').Vault[]} */
  vault: [],
  /** @type {import('./models/Vault.js').Vault | null} */
  isprivate: null,
  activeVault: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  myVaults: [],
  profileVault: [],
  /** @type {import('./models/VaultKeep.js').VaultKeep[]} */
  vaultkeeps: [],
})
