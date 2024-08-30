import { Account } from "./Account.js";
import { Keep } from "./Keep.js";
import { Vault } from "./Vault.js";

export class VaultKeep {
  constructor(data) {
    this.id = data.id;
    this.vaultId = data.vaultId;
    this.keepId = data.keepId;
  }
}

export class VaultKeepKeep extends Keep {
  constructor(data) {
    super(data);
    this.vaultKeepId = data.vaultKeepId;
    this.vaultId = data.vaultId;
  }
}

export class VaultProfile extends VaultKeep {
  constructor(data) {
    super(data)
    this.profile = new Account(data.profile)
  }
}

export class VaultKeepVault extends VaultKeep {
  constructor(data) {
    super(data)
    this.vault = new Vault(data.album)
  }
}
