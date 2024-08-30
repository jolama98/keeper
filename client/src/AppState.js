import { reactive } from 'vue'
import { Keep, VaultKeepKeep } from './models/Keep.js'
import { Vault } from './models/Vault.js'
import { VaultKeep, VaultKeepVault, VaultProfile } from './models/VaultKeep.js'
import { Profile } from './models/Profile.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {Keep[]} */

  // SUPPORTS THE HOME PAGE
  keeps: [],
  /** @type {Keep} */
  setActiveKeep: null,
  /** @type {VaultKeepVault[]} */
  accountVaults: [],

  // USED FOR THE VAULTDETAILS PAGE
  /** @type {Vault}  */
  activeVault: null,
  /**@type {VaultKeepKeep[]} */
  vaultKeeps: [],

  // THE PROFILE PAGE
  /** @type {Profile} */
  profile: null,
  /** @type {Keep[]} */
  profileKeeps: [],
  /** @type {Vault[]}  */
  profileVaults: []

})

