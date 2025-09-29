Use Conventional Commits with scoped emoji, for example `feat(prototype): :video_game: add spike hazard tweak`.
Pull requests should link issues or milestones, summarize gameplay impact, list the editor or batch commands you ran, and attach captures whenever visuals or effects change.
Note any data migrations needed for ScriptableObjects.


Use the following for all commit messages:
Each commit message consists of a header, a body and a footer. The header has a special format that includes a type, a scope and a subject:
<Type>(<Scope>): <Subject>
<BLANK LINE>
<Body>
<BLANK LINE>
<Fotter>


### Header:

The header is mandatory and the scope of the header is optional, and should follow these rules:
  * Be concise
  * 72 characters or less (GitHub truncates this otherwise)
  * Describe exactly what the commit is doing

If the commit reverts a previous commit, it should begin with `Revert:' followed by the header of the reverted commit.
In the body it should say: `This reverts commit <hash>.`, where the hash is the SHA of the commit being reverted.

### Type:

  * build -> Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
  * revert -> Revert changes
  * ci -> Updating continuous integration
  * docs -> Writing documentation
  * feat -> A new feature
  * fix -> Fixing a bug
  * perf -> A code change that improves performance
  * refactor: A code change that neither fixes a bug nor adds a feature
  * style: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
  * chore -> Often manual chore
  * tests -> Writing tests

### Scope:

The scope should be the name of the npm package affected (as perceived by the person reading the changelog generated from commit messages.
There are currently a few exceptions to the "use package name" rule:
  * packaging: used for changes that change the npm package layout in all of our packages, e.g. public path changes, package.json changes done to all packages, d.ts file/format changes, changes to bundles, etc.
  * changelog: used for updating the release notes in CHANGELOG.md
  * aio: used for docs-app (angular.io or DocFX) related changes within the /aio or /docs directory of the repo
  * none/empty string: useful for style, test and refactor changes that are done across all packages (e.g. style: add missing semicolons)

### Subject:

The subject contains a succinct description of the change:
  * use the imperative, present tense: "change" not "changed" nor "changes"
  * don't capitalize the first letter
  * no dot (.) at the end

Start the subject with one of the following for the following types:
  * build:
    * 📦️ :package: Add or update compiled files or packages.
    * ⬇️ :arrow_down: Downgrade dependencies.
    * ⬆️ :arrow_up: Upgrade dependencies.
    * 📌 :pushpin: Pin dependencies to specific versions.
    * ➕ :heavy_plus_sign: Add a dependency.
    * ➖ :heavy_minus_sign: Remove a dependency.
  * revert: ⏪️ :rewind: Revert changes.
  * ci: 💚 :green_heart: Fix CI Build. 👷 :construction_worker: Add or update CI build system. 🔨 :hammer: Add or update development scripts. 🙈 :see_no_evil: Add or update a .gitignore file. 🦺 :safety_vest: Add or update code related to validation. 📦️ :package: Add or update compiled files or packages. ⬇️ :arrow_down: Downgrade dependencies. ⬆️ :arrow_up: Upgrade dependencies. 📌 :pushpin: Pin dependencies to specific versions. ➕ :heavy_plus_sign: Add a dependency. ➖ :heavy_minus_sign: Remove a dependency.
  * docs:
    * 📝 :memo: Add or update documentation.
    * 📄 :page_facing_up: Add or update license.
    * ✏️ :pencil2: Fix typos.
  * feat: ✨ :sparkles: Introduce new features.
  * fix:
    * 🐛 :bug: Fix a bug.
    * 🚑️ :ambulance: Critical hotfix.
    * 🔒️ :lock: Fix security or privacy issues.
    * 🚨 :rotating_light: Fix compiler / linter warnings.
    * 🩹 :adhesive_bandage: Simple fix for a non-critical issue. pref, refactor, style,
  * chore:
    * 🎉 :tada: Begin a project.
    * 🚧 :construction: Work in progress.
    * 🔖 :bookmark: Release / Version tags.
    * 🏷️ :label: Add or update types.
    * 🚩 :triangular_flag_on_post: Add, update, or remove feature flags.
    * 📸 :camera_flash: Add or update snapshots.
    * 🤡 :clown_face: Mock things.
    * 🥚 :egg: Add or update an easter egg.
    * ⚗️ :alembic: Perform experiments.
    * 🎨 :art: Improve structure / format of the code.
    * ⚡️ :zap: Improve performance.
    * 🔥 :fire: Remove code or files.
    * ♻️ :recycle: Refactor code.
    * 💬 :speech_balloon: Add or update text and literals.
    * 👽️ :alien: Update code due to external API changes.
    * 💡 :bulb: Add or update comments in source code.
    * 🗑️ :wastebasket: Deprecate code that needs to be cleaned up.
    * ⚰️ :coffin: Remove dead code.
    * 🛂 :passport_control: Work on code related to authorization, roles and permissions.
    * 🥅 :goal_net: Catch errors.
    * 🧵 :thread: Add or update code related to multithreading or concurrency.
    * 💩 :poop: Write bad code that needs to be improved.
    * 🍻 :beers: Write code drunkenly.
    * 💄 :lipstick: Add or update the UI and style files.
    * 🧑‍💻 :technologist: Improve developer experience.
    * 📱 :iphone: Work on responsive design.
    * 🔐 :closed_lock_with_key: Add or update secrets.
    * 🌐 :globe_with_meridians: Internationalization and localization.
    * 🚚 :truck: Move or rename resources (e.g.: files, paths, routes).
    * 🏗️ :building_construction: Make architectural changes.
    * 🧱 :bricks: Infrastructure related changes.
    * 🗃️ :card_file_box: Perform database related changes.
    * 🧐 :monocle_face: Data exploration/inspection.
    * 🍱 :bento: Add or update assets.
    * ♿️ :wheelchair: Improve accessibility.
    * 🔊 :loud_sound: Add or update logs.
    * 🔇 :mute: Remove logs.
    * 👥 :busts_in_silhouette: Add or update contributor(s).
    * 🚸 :children_crossing: Improve user experience / usability.
    * 🔍️ :mag: Improve SEO.
    * 🌱 :seedling: Add or update seed files.
    * 💫 :dizzy: Add or update animations and transitions.
    * 👔 :necktie: Add or update business logic.
    * 🩺 :stethoscope: Add or update healthcheck.
    * 💸 :money_with_wings: Add sponsorships or money related infrastructure.
    * 🔧 :wrench: Add or update configuration files
    * 🚀 :rocket: Deploy stuff.
    * 🔀 :twisted_rightwards_arrows: Merge branches.
  * tests:
    * ✅ :white_check_mark: Add, update, or pass tests.
    * 📈 :chart_with_upwards_trend: Add or update analytics or track code.
      *  🧪 :test_tube: Add a failing test.

If this is a Breaking Change add :boom: to the beging of the subject.

### Body:

Just as in the subject, use the imperative, present tense: "change" not "changed" nor "changes".
The body should include the motivation for the change and contrast this with previous behavior.

### Footer:

The footer should contain any information about Breaking Changes and is also the place to reference GitHub issues that this commit Closes.

Breaking Changes should start with the word `BREAKING CHANGE:` with a space or two newlines.
The rest of the commit message is then used for this.

Closed bugs should be listed on a separate line in the footer prefixed with "Closes" keyword like this: `Closes #234`
or in case of multiple issues: `Closes #123, #245, #992`

### Examples:

#### Commit message with scope and fotter

```
feat($browser): :sparkles: onUrlChange event
(popstate/hashchange/polling)

Added new event to $browser:
 - forward popstate event if available
 - forward hashchange event if popstate not available
 - do polling when neither popstate nor hashchange available

Breaks $browser.onHashChange, which was removed (use onUrlChange instead)
```

#### Commit message with scope and fotter that closes issue #392

```
fix($compile): :adhesive_bandage: couple of unit tests for IE9
 
Older IEs serialize html uppercased, but IE9 does not...
Would be better to expect case insensitive, unfortunately jasmine does not allow to user regexps for throw expectations.
 
Closes #392
Breaks foo.bar api, foo.baz should be used instead
```

#### Commit message with scope and fotter that closes issue #351

```
feat(directive): :sparkles: ng:disabled, ng:checked, ng:multiple, ng:readonly, ng:selected New directives for proper binding these attributes in older browsers (IE). Added coresponding description, live examples and e2e tests. Closes #351
```

#### Commit message with scope and no body

```
style($location): :goal_net: add couple of missing semi colons
```

#### Commit message with scope

```
docs(guide): :memo: updated fixed docs from Google Docs

Couple of typos fixed:
  - indentation
  - batchLogbatchLog -> batchLog
  - start periodic checking
  - missing brace
```

#### Commit message with scope and a breaking change

"""
feat($compile)!: :boom: :sparkles: simplify isolate scope bindings

Changed the isolate scope binding options to:
  - @attr
  - attribute binding (including interpolation)
  - =model - by-directional model binding
  - &expr - expression execution binding

This change simplifies the terminology as well as number of choices available to the developer.
It also supports local name aliasing from the parent.

BREAKING CHANGE: isolate scope bindings definition has changed and the inject option for the directive controller injection was removed.

To migrate the code follow the example below:

Before:

```
scope: {
    myAttr: 'attribute',
    myBind: 'bind',
    myExpression: 'expression',
    myEval: 'evaluate',
    myAccessor: 'accessor'
}
```

After:

```
scope: {
    myAttr: '@',
    myBind: '@',
    myExpression: '&',
    // myEval - usually not useful, but in cases where the expression is assignable, you can use '='
    myAccessor: '=' // in directive's template change myAccessor() to myAccessor
}
```

The removed inject wasn't generaly useful for directives so there should be no code using it.
"""

#### Commit message with no body and a breaking change

```
feat: :boom: :sparkles: allow provided config object to extend other configs

BREAKING CHANGE: 'extends' key in config file is now used for extending other config files.
```

#### Commit message with no body

```
docs: :pencil2: correct spelling of CHANGELOG
```

#### Commit message with multi-paragraph body and multiple footers

```
fix: :bug: prevent racing of requests

Introduce a request id and a reference to latest request. Dismiss incoming responses other than from the latest request.

Remove timeouts which were used to mitigate the racing issue but are obsolete now.

Reviewed-by: Z
Refs: #123
```

#### Commit message for a minor bug

```
fix fix(ui): :bug: resolve issue with dropdown menu alignment

The dropdown menu was misaligned on the profile page due to CSS conflicts.
Updated the styles to ensure proper alignment across different screen sizes.
Fixes issue #789.
```

#### Commit message for adding a new test

```
test: :test_tube: add unit tests for user authentication module

Added unit tests for the user authentication module to cover login, registration, and token verification functionalities.
Ensured all tests pass with the new authentication logic.
Refs: #456
```

#### Commit message for a configuration change

```
chore(config): :wrench: update ESLint configuration to support latest standards

Updated the ESLint configuration to support the latest JavaScript standards and best practices.
Included new rules for code formatting and improved error detection.
Reviewed-by: A, B
```