## Fireworks Simulator

Monogame C# application running on NET 8.0

An interactive fireworks display simulator featuring particle physics, gravity effects, and customizable explosion patterns.

### Softwares/Libraries used

- Visual Studio 2022
- .NET 8.0 SDK
- MonoGame Framework

### Building the Project
1. Clone this repository from the GitLab 510 group, section 1 group, ionita group
2. Open the solution in Visual Studio 2022
4. Build the solution & run it

### Running the Application

**Option 2: Download from CI Pipeline**
1. Go to the GitLab repository
2. Navigate to CI/CD -> Pipelines
3. Select the latest successful pipeline
4. Download the `artifacts` from the `build:release` job
5. Unzip and run `FireworksSimulator.exe`

## Controls

- **Space**: Launch a firework
- **Left Click**: Create a particle at cursor position
- **Right Click**: Add a rectangle shape
- **Middle Click**: Clear all shapes
- **Escape**: Exit application

## Features

- Realistic particle physics with gravity
- Randomized firework colors and explosion patterns
- Fade trail effects for visual appeal
- Resizable window with proper aspect ratio scaling
- 60-100 particles per explosion
- Dark night sky background

## Testing

Unit tests are included in the `FireworksTests` and `ShapeLibraryTests` projects. Run tests using Visual Studio Test Explorer or via the CI pipeline.


## Credits

Made by Andy Ionita, 2333068
Programming IV, Dirk Dubois, Section 1